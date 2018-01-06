I set myself the goal of learning new programming languages. For the purpose of this goal, a language is considered learned once I successfully code Dijkstra's shortest path algorithm in the langauge according to this specification.

**INPUT**: An undirected graph with edges weighted by nonnegative integers, a start node and an end note. The graph is given as a text file where each line is of the format "startnode:weight:endnode" where startnode and endnode are arbitrary strings that don't include the color or the newline.

The first line is of the form `#start#end#27#start:a:c:d:end#`, a hash-separated string where the cells are, in order: name of the start node, name of the finish node, expected length of shortest path, expected nodes in shortest path separated by colons. The line is terminated in a hash character. If no path exists, the expected length is instead '`FAIL`'.

**OUTPUT**: Weight of the shortest path, and a sequence of nodes, starting with startnode and ending with endnote, that corresponds to this shortest path; or an error message if the shortest path doesn't exist. 

**ALGORITHM**:
 1. For each vertex v, set d(v) := infinity; p(v) := null
 2. Set d(startnode) := 0
 3. Set open := [startnode]
 4. While (open is not empty)
  a) u := extract-minimum(open); close.add(u);
  b) If u == target: go to step 6. 
  c) For each neighbour v of u:
      i) if (closed(v)) skip;
     ii) alt := d[u] + weight[u, v]
	iii) if (alt < d[v]) d[v] := alt; p[v] := u; open.add(v);
5. If target was not reached, terminate with failure.
6. Unfold path:
  a) path = []
  b) node = target
  c) while node != start
    i) path = [node:path]
   ii) node = node.parent
  d) path = [start:path]  

**EXAMPLES**:
See the files `1.txt` up to `5.txt` in the folder `data`.