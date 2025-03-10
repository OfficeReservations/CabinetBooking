﻿namespace CabinetBooking.Domain.Common.EF;

public interface IEventPublisher : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task EventPublish(object entity, CancellationToken cancellationToken = default);
}