namespace Events.Domain.Enums;

/// <summary>
///     Перечисление форматов мероприятий.
/// </summary>
public enum EventFormatEnum
{
	/// <summary>
	///     Офлайн.
	/// </summary>
	Offline = 1,

	/// <summary>
	///     Онлайн.
	/// </summary>
	Online = 2,

	/// <summary>
	///     Гибридный (офлайн + онлайн).
	/// </summary>
	Hybrid = 3
}