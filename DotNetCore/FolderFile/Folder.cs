using System.Collections.Generic;

namespace FolderFile
{
    public class Folder
    {
        public string Name { get; set; }

        public List<File> Files { get; set; }
        
        public List<Folder> Folders { get; set; }

        public int GetContainsNumber() {
            int filesCount = 0;
            if(Files != null) {
                filesCount = Files.Count;
            }

            int foldersCount = 0;
            if(Folders != null) {
                foldersCount = Folders.Count;
            }

            return filesCount + foldersCount;
        }

        public List<string> ListChildren(string parent_path = null) {
            /*const*/ string basename = (parent_path!=null) ? (parent_path + this.Name + "/") : "";
            List<string> list = new List<string>();
            if(parent_path != null)
                list.Add(basename);
            /*if(this.Files != null)
                list.AddRange(this.Files.ConvertAll(f => basename+f.Name));*/
            this.Files?.ForEach(f => list.Add(basename+f.Name));
            this.Folders?.ConvertAll(f => f.ListChildren(basename)).ForEach(l => list.AddRange(l));
            return list;
        }
    }
}
