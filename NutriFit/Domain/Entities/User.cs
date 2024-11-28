namespace Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public double Weight { get; private set; }
    public double Height { get; private set; }

    public User(string name, string email, string passwordHash, double weight, double height)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Nome é obrigatório");
        if (!IsValidEmail(email)) throw new ArgumentException("Formato de email inválido");
        if (weight <= 0) throw new ArgumentException("O seu peso tem que ser maior do que 0");
        if (height <= 0) throw new ArgumentException("A sua altura tem que ser maior do que 0");

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Weight = weight;
        Height = height;
    }

    private bool IsValidEmail(string email) =>
        new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
}
