using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;

namespace SchoolCMS.Helpers
{
    public static class InformationSourceFileHelper
    {
        public static void ManageFiles(this InformationSource informationSource, IEnumerable<int> filesToRemove,
            IEnumerable<int> filesToAdd,CmsContext context)
        {

                RemoveFiles(informationSource, filesToRemove,context);
                AddFiles(informationSource, filesToAdd, context);

        }

        private static void RemoveFiles(InformationSource informationSource, IEnumerable<int> filesToRemove,CmsContext context)
        {
            if (filesToRemove == null) return;
            var contextFilesToRemove = context.Files.Where(x => filesToRemove.Contains(x.Id));

            foreach (var fileToRemove in contextFilesToRemove)
            {
                if (informationSource.Files.Contains(fileToRemove))
                {
                    informationSource.Files.Remove(fileToRemove);
                }
            }
        }

        private static void AddFiles(InformationSource informationSource, IEnumerable<int> filesToAdd,CmsContext context)
        {
            if (filesToAdd == null) return;
            var contextFilesToAdd = context.Files.Where(x => filesToAdd.Contains(x.Id));

            if (!contextFilesToAdd.Any()) return;
            foreach (var fileToAdd in contextFilesToAdd)
            {
                if (!informationSource.Files.Contains(fileToAdd))
                {
                    informationSource.Files.Add(fileToAdd);
                }
            }
        }
    }
}