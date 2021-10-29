namespace MinhLam.XemPhim.Application.Commands
{
    public class AddNewAboutCommand
    {
        public AddNewAboutCommand(
            string name,
            string description,
            string image,
            bool isActive)
        {
            Name = name;
            Description = description;
            Image = image;
            IsActive = isActive;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
    }
}
