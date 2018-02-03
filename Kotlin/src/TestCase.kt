import java.io.File
import kotlin.math.exp

class TestCase(val file: File) {

    fun run() {
        print ("Running " + this.file + "... ")
        val lines = file.readLines()
        // #start#end#27#start:a:c:d:end#
        val metadata = lines[0]
        val assignment = Assignment()
        lines.stream().skip(1).filter({ it != null && !it.equals("") }).forEach {
            val split = it.split(':')
            val node1s = split[0]
            val distance = split[1].toInt()
            val node2s = split[2]
            assignment.addEdge(node1s, distance, node2s)
        }
        val metadataSplit = metadata.split('#')
        assignment.startNode = assignment.allNodes[metadataSplit[1]]
        assignment.finishNode = assignment.allNodes[metadataSplit[2]]
        val expectSuccess = metadataSplit[3] != "FAIL"
        val result = computeDijkstra(assignment)
        if (result.successful) {
            if (!expectSuccess) {
                println("fail! (unexpectedly succeeded)")
                return
            }
            if (result.pathLength != metadataSplit[3].toInt()) {
                println("fail! (bad path length)")
                return
            }
            val nodeNames = metadataSplit[4].split(':')
            if (nodeNames.size != result.bestPath.size) {
                println("fail! (bad node count)")
                return
            }
            for (i in 0 until nodeNames.size) {
                if (nodeNames[i] != result.bestPath[i].name) {
                    println("fail! (bad path)")
                    return
                }
            }
            println("OK!")
        } else {
            if (expectSuccess) {
                println("fail! (unexpectedly failed!)")
            } else {
                println("OK!")
            }
        }
    }
}