using System;
using System.IO;
using System.Threading;


namespace R5T.NetStandard
{
    public static class DirectoryHelper
    {
        public static void Create(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        /// <summary>
        /// Deletes a directory path.
        /// The <see cref="System.IO.Directory.Delete(string)"/> method throws a <see cref="System.IO.DirectoryNotFoundException"/> if attempting to delete a non-existent directory. This is annoying.
        /// All you really want is the directory to not exist, so this method simply takes care of checking if the directory exists.
        /// Also annoying, you need to specify the recursive option to delete a directory with anything in it. This method also takes care of specifying true for the recursive option.
        /// Even more annoying, even after specifying the recursive option, the system method will not delete read-only files. Thus this method disables read-only options on all files recursively.
        /// </summary>
        public static void Delete(string directoryPath)
        {
            if(Directory.Exists(directoryPath))
            {
                DirectoryHelper.DisableReadOnly(directoryPath);

                Directory.Delete(directoryPath, true);
            }
        }

        public static void DisableReadOnly(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            DirectoryHelper.DisableReadOnly(directoryInfo);
        }

        /// <summary>
        /// Remove the read-only attribute from all files.
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/questions/1982209/cannot-programatically-delete-svn-working-copy
        /// </remarks>
        public static void DisableReadOnly(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.IsReadOnly)
                {
                    file.IsReadOnly = false;
                }
            }

            foreach (var subdirectory in directoryInfo.GetDirectories())
            {
                DirectoryHelper.DisableReadOnly(subdirectory);
            }
        }

        /// <summary>
        /// It's often a good idea to wait a bit after deleting a directory.
        /// This allows the system and any shell extensions (TortoiseSVN, TortoiseGit, etc.) to complete their tasks.
        /// </summary>
        /// <remarks>
        /// The <see cref="DirectoryHelper"/> offers this functionality for ease of use, allowing client code to skip using the threading namespace, the <see cref="Thread"/> class, etc.
        /// </remarks>
        public static void SleepAfterDelete(int numberOfMilliseconds = 1000)
        {
            Thread.Sleep(numberOfMilliseconds);
        }
    }
}
