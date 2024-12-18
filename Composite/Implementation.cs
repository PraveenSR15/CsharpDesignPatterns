namespace Composite
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        protected FileSystemItem(string name)
        {
            Name = name;
        }
        public abstract long GetSize();
    }
    public class File : FileSystemItem
    {
        private long _size;

        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }

    public class Directory : FileSystemItem
    {
        List<FileSystemItem> _files = new List<FileSystemItem>();
        private long _size;

        public Directory(string name, long size) : base(name)
        {
            _size = size;
        }

        public void Add(FileSystemItem file)
        {
            _files.Add(file);
        }

        public void Remove(FileSystemItem file)
        { 
            _files.Remove(file); 
        }

        public override long GetSize()
        {
            var treeSize = _size;
            foreach (FileSystemItem file in _files)
                treeSize += file.GetSize();
            return treeSize;
        }
    }
}
