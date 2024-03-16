using AutoMapper;
using eSocial.Application.Contracts;
using eSocial.Domain.MessageAggregate;
using FluentValidation;
using MediatR;

namespace eSocial.Application.Features.FeatureMessage.Commands;

public class CreateMessageCommand : IRequest<Message>
{
    public string FromId { get; set; } = default!;

    public string ToId { get; set; } = default!;

    public string Content { get; set; } = default!;
    
    public string? ReplyMessageId { get; set; }
    
    public MessageType Type { get; set; }
}

public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(x => x.FromId).NotEmpty();
        RuleFor(x => x.ToId).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
    }
}

public class CreateMessageCommandHandler(IMessageService messageService, IMapper mapper) : IRequestHandler<CreateMessageCommand, Message>
{
    public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var document = mapper.Map<Message>(request);
        var result = await messageService.CreateAsync(document);
        return result;
    }
}