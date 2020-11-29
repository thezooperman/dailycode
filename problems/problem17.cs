using System;
using System.Collections;

namespace problems
{
    class Problem17
    {
        /*
           Suppose we represent our file system by a string in the following manner:

           The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:

           dir
               subdir1
               subdir2
                   file.ext

           The directory dir contains an empty sub-directory subdir1 and a sub-directory
           subdir2 containing a file file.ext.

           The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:

           dir
               subdir1
                   file1.ext
                   subsubdir1
               subdir2
                   subsubdir2
                       file2.ext

           The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a
           file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a
           second-level sub-directory subsubdir2 containing a file file2.ext.

           We are interested in finding the longest (number of characters) absolute path to a file
           within our file system. For example, in the second example above, the longest absolute
           path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the
           double quotes).

           Given a string representing the file system in the above format, return the length of
           the longest absolute path to a file in the abstracted file system. If there is no file
           in the system, return 0.

           Note:

           The name of a file contains at least a period and an extension.

           The name of a directory or sub-directory will not contain a period.
        */

        public int problem17(string path)
        {
            // split the string by new statement - \n
            String[] paths = path.Split("\n");

            int max = 0;
            // setup an associated array to store the previous path
            int[] lengths = new int[paths.Length + 1];

            // start iteration
            foreach (String p in paths)
            {
                // /t determines directory/file level nesting
                int lev = p.LastIndexOf("\t") + 1;

                // only files can contain '.'
                if (p.Contains("."))
                {
                    // path from dir to file is length of file _+ pre-level length
                    int curlength = p.Length - lev + (lev == 0 ? 0 : lengths[lev - 1]);
                    max = Math.Max(max, curlength);
                }
                else
                {
                    // store the length of a particular level, with the previous level length
                    lengths[lev] = (lev == 0 ? 0 : lengths[lev - 1]) + p.Length - lev + 1;
                }
            }
            return max;
        }
    }
}