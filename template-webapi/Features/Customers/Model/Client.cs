namespace template_webapi.Features.Clients.Model
{
    public class Client
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
