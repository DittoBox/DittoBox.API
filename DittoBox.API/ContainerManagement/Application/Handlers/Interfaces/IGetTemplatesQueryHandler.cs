using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IGetTemplatesQueryHandler
    {
        public Task<ICollection<TemplateResource>> Handle(GetTemplatesQuery query)
    }
}