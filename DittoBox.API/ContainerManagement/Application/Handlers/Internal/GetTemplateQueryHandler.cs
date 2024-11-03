using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class GetTemplateQueryHandler : IGetTemplateQueryHandler
    {
        public Task<TemplateResource> Handle(GetTemplateQuery query)
        {
            throw new NotImplementedException();
        }
    }
}