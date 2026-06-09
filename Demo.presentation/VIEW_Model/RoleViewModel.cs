namespace Demo.presentation.VIEW_Model
{
    public class RoleViewModel
    {

        public string Id {  get; set; }
        public string Name {  get; set; }

        public List<UserRoleViewModelcs> Users { get; set; }
        public RoleViewModel()
        {
            Id=Guid.NewGuid().ToString();
        }
    }
}
