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

        public List<string> ListChildren(bool ordered =false, string parent_path = null) {
            /*const*/ string _base = (parent_path!=null) ? (parent_path + this.Name + "/") : "";
            List<string> list = new List<string>();
            if(parent_path != null)
                list.Add(_base);
            /*if(this.Files != null)
                list.AddRange(this.Files.ConvertAll(f => basename+f.Name));*/
            this.Files?.ForEach(f => list.Add(_base+f.Name));
            this.Folders?.ConvertAll(f => f.ListChildren(false, _base)).ForEach(l => list.AddRange(l));
            if(ordered) list.Sort();
            return list;
        }
    }
}
