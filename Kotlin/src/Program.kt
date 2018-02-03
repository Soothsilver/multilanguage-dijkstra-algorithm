
import java.io.File

fun main(args: Array<String>) {
    for (filename in File(""".""").walk()) {
        if (!filename.toString().endsWith(".txt")) {
            continue
        }
        val testCase = TestCase(filename)
        testCase.run()
    }
}
