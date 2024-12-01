public class User
{
    public string Name { get; set; }  // A propriedade é do tipo string, e pode ser nula
    public string Senha { get; set; } // A propriedade 'senha' também deve ser tratada corretamente
    public bool Logado { get; set; }
    public bool Bloqueado { get; set; }

    public User(string name, string senha)
    {
        this.Name = name;
        this.Senha = senha;
    }
}
