import os

from TestCase import TestCase

for filename in os.listdir('.'):
    testCase = TestCase(filename)
    testCase.run()


# """
#
# import java.io.File
#
# fun main(args: Array<String>) {
#     for (filename in File(""".""").walk()) {
#         if (!filename.toString().endsWith(".txt")) {
#             continue
#         }
#         val testCase = TestCase(filename)
#         testCase.run()
#     }
# }
#
# """