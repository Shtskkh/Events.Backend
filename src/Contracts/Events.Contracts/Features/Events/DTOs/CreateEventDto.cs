using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Создание мероприятия.
/// </summary>
public class CreateEventDto
{
    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    [MinLength(DomainConstraints.Event.Title.MinLength)]
    [MaxLength(DomainConstraints.Event.Title.MaxLength)]
    public required string Title { get; set; }

    /// <summary>
    ///     Анонс мероприятия.
    /// </summary>
    [MinLength(DomainConstraints.Event.Announcement.MinLength)]
    [MaxLength(DomainConstraints.Event.Announcement.MaxLength)]
    public required string Announcement { get; set; }


    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    [MinLength(DomainConstraints.Event.Description.MinLength)]
    [MaxLength(DomainConstraints.Event.Description.MaxLength)]
    public required string Description { get; set; }

    /// <summary>
    ///     Дата и время начала мероприятия.
    /// </summary>
    public required DateTimeOffset StartDateTime { get; set; }


    /// <summary>
    ///     Дата и время окончания мероприятия.
    /// </summary>
    public required DateTimeOffset EndDateTime { get; set; }

    /// <summary>
    ///     Превью изображения для мероприятия.
    /// </summary>
    public IFormFile? Preview { get; set; }
}