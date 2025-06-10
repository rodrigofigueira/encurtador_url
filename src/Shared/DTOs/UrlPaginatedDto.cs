namespace Shared.DTOs;

public record UrlPaginatedDto(IEnumerable<UrlDto> urls, int total);
