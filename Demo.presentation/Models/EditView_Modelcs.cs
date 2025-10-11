namespace Demo.presentation.Models
{
    public class EditView_Modelcs
    {



        public int id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly Created_on { get; set; } = default;

    }
}
