namespace LyricsEditorPro.ViewModels
{
    internal class MainVM : BaseVM
    {
		public BaseVM CurrentVM { get; }
        public MainVM()
        {
            CurrentVM = new HomeVM();
        }
	}
}
 