using System.Collections.Generic;

namespace FolderFile {
    interface IEnumerable {
        List<string> ListChildren(bool ordered =false, string parent_path = null);
    }
}
