import sys

from Assignment import DijkstraResult


def _get_node_with_least_best_distance(list):
    best_dist_so_far = sys.maxint
    best_node_so_far = None
    for node in list:
        if node.best_distance < best_dist_so_far:
            best_dist_so_far = node.best_distance
            best_node_so_far = node
    return best_node_so_far


def compute_dijkstra (assignment):
    assignment.start_node.best_distance = 0
    open_list = []
    closed_list = []
    open_list.append(assignment.start_node)
    while len(open_list) > 0:
        u = _get_node_with_least_best_distance(open_list)
        open_list.remove(u)
        closed_list.append(u)
        if u == assignment.finish_node:
            break
        for e in u.edges:
            if e.to in closed_list:
                continue
            alt = u.best_distance + e.distance
            if alt < e.to.best_distance:
                e.to.best_distance = alt
                e.to.best_parent = u
            if e.to not in open_list:
                open_list.append(e.to)

    if assignment.finish_node.best_parent is None:
        return DijkstraResult(False)
    unfolded_path = []
    node = assignment.finish_node
    while node is not assignment.start_node:
        unfolded_path.insert(0, node)
        node = node.best_parent
    unfolded_path.insert(0, assignment.start_node)
    result = DijkstraResult(True)
    result.best_path = unfolded_path
    result.path_length = assignment.finish_node.best_distance
    return result
