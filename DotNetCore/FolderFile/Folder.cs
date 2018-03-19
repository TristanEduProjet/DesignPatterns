using System.Collections.Generic;

namespace FolderFile
{
    public class Folder : INode, IEnumerable
    {
        private string _name;
        public string /*INode.*/Name { get{return this._name;} set{this._name=value+"/";} }

        public List<INode> childs { get; set; } = new List<INode>();

        public int GetContainsNumber() {
            return this.childs.Count;
        }

        public List<Folder> getFolders() {
            return this.childs.FindAll(e => e is Folder).ConvertAll(e => e as Folder);
        }

        public List<File> getFiles() {
            return this.childs.FindAll(e => e is File).ConvertAll(e => e as File);
        }

        public List<string> /*IEnumerable.*/ListChildren(bool ordered =false, string parent_path = null)
        {
            //throw new System.NotImplementedException();
            /*const*/ string _base = (parent_path!=null) ? (parent_path + this.Name + "/") : "";
            List<string> list = new List<string>();
            /*if(parent_path != null)
                list.Add(_base);*/
            this.childs?.ForEach(c => list.Add(_base+c.Name));
            this.childs?.FindAll(c => c is IEnumerable)
                        .ConvertAll(e => e as IEnumerable)
                        .ConvertAll(e => e.ListChildren(false, _base))
                        .ForEach(l => list.AddRange(l));
            if(ordered) list.Sort();
            return list;
        }
    }
}
