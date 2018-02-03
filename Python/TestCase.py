import sys

from Assignment import Assignment
from dijkstra import compute_dijkstra


class TestCase:
    def __init__(self, filename):
       self.filename = filename

    def run(self):
        sys.stdout.write('Running ' + self.filename + '... ')
        with open(self.filename) as file:
            lines = file.readlines()
        metadata = lines[0]
        assignment = Assignment()
        for line in lines[1:]:
            line = line.strip()
            if not line:
                continue
            split = line.split(':')
            node1s = split[0]
            distance = int(split[1])
            node2s = split[2]
            assignment.add_edge(node1s, distance, node2s)
        metadataSplit = metadata.split('#')
        assignment.start_node = assignment.all_nodes[metadataSplit[1]]
        assignment.finish_node = assignment.all_nodes[metadataSplit[2]]
        expect_success = metadataSplit[3] != 'FAIL'
        result = compute_dijkstra(assignment)
        if result.successful:
            if not expect_success:
                print 'fail! (unexpectedly succeeded)'
                return
            if result.path_length != int(metadataSplit[3]):
                print 'fail! (bad path length)'
                return
            node_names = metadataSplit[4].split(':')
            if len(node_names) != len(result.best_path):
                print 'fail! (bad node count)'
                return
            for i in xrange(0, len(node_names)):
                if node_names[i] != result.best_path[i].name:
                    print 'fail! (bad path)'
                    return

            print 'OK!'
        elif expect_success:
            print 'fail! (unexpectedly failed)'
        else:
            print 'OK!'