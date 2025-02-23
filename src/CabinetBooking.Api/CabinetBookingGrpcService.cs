using CabinetBooking.Application.Commands;
using Grpc.Core;
using MediatR;

namespace CabinetBooking.Api;

public class CabinetBookingGrpcService(IMediator mediator) : CabinetBookingService.CabinetBookingServiceBase
{
    public override async Task<AddCabinetResponse> AddCabinet(AddCabinetRequest request, ServerCallContext context)
    {
        var command = new AddCabinet
        {
            Number = request.Cabinet.Number,
            IsProjector = request.Cabinet.IsProjector,
            IsTechnical = request.Cabinet.IsTechnical,
            CabinetType = (Domain.CabinetType)request.Cabinet.CabinetType
        };
        
        var response = await mediator.Send(command, CancellationToken.None);
        return new AddCabinetResponse{Number = response};
    }
}