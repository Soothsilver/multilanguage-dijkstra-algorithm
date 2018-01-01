I set myself the goal of learning new programming languages. For the purpose of this goal, a language is considered learned once I successfully code Dijkstra's shortest path algorithm in the langauge according to this specification.

**INPUT**: An undirected graph with edges weighted by nonnegative integers, a start node and an end note. The graph is given as a text file where each line is of the format "startnode:weight:endnode" where startnode and endnode are arbitrary strings that don't include the color or the newline.

**OUTPUT**: Weight of the shortest path, and a sequence of nodes, starting with startnode and ending with endnote, that corresponds to this shortest path; or an error message if the shortest path doesn't exist.

**ALGORITHM**:
 1. For each vertex v, set d(v) := infinity; p(v) := null
 2. Set d(startnode) := 0
 3. Set open := [startnode]
 4. While (open is not empty)
  a) u := extract-minimum(open); close.add(u);
  b) For each neighbour v of u:
    i) if (closed(v)) skip;
    ii) alt := d[u] + weight[u, v]
	iii) if (alt < d[v]) d[v] := alt; p[v] := u; open.add(v);

**EXAMPLES**:
 TODO