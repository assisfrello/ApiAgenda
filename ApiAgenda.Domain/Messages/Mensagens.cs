namespace ApiAgenda.Domain.Messages;

public class Mensagens
{
    public int CodigoMensagem { get; set; }
    public string? Mensagem { get; set; }
    
    public static Mensagens Sucesso()
    {
        return new() {CodigoMensagem = 100, Mensagem = "Operação realizada com sucesso"};
    }
        
    public static Mensagens ConsultaSemResultados()
    {
        return new() {CodigoMensagem = 102, Mensagem = "A consulta não obteve resultados!"};
    }
    
    public static Mensagens Obrigatorio()
    {
        return new() {CodigoMensagem = 400, Mensagem = "O campo {0} é obrigatório"};
    }
    
    public static Mensagens CampoInvalido()
    {
        return new() {CodigoMensagem = 400, Mensagem = "O campo {0} é inválido"};
    }
    
    
}