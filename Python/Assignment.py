import sys


class Assignment:
    def __init__(self):
        self.start_node = None
        self.finish_node = None
        self.all_nodes = {}

    def add_edge(self, node1s, distance, node2s):
        if not self.all_nodes.has_key(node1s):
            self.all_nodes[node1s] = Node(node1s)
        if not self.all_nodes.has_key(node2s):
            self.all_nodes[node2s] = Node(node2s)
        one = self.all_nodes[node1s]
        two = self.all_nodes[node2s]
        one.edges.append(Edge(one, two, distance))
        two.edges.append(Edge(two, one, distance))

class Node:
    def __init__(self, name):
        self.name = name
        self.edges = []
        self.best_distance = sys.maxint
        self.best_parent = None

class Edge:
    def __init__(self, source, to, distance):
        self.source = source
        self.to = to
        self.distance = distance

class DijkstraResult:
    def __init__(self, successful):
        self.successful = successful
        self.best_path = None
        self.path_length = 0
