using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Outbox;

public class NewMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Compose new mail";

    public NewMailAction(EmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public void Open()
    {
        
    }
}