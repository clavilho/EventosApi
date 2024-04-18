namespace EventoGerenciador.Infrastructure.Sql;

public class ParticipanteSql
{
    public const string InserirParticipante = @"INSERT INTO [Participante]
                                                ([Id]          
                                                ,[Nome]          
                                                ,[Email]          
                                                ,[EventoId]         
                                                ,[Data_Criacao])   
                                                VALUES          
                                                (@id          
                                                ,@nome        
                                                ,@email         
                                                ,@eventoId         
                                                ,@dataCriacao)";
}
