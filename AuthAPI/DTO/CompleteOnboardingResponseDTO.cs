#nullable enable

using System;

namespace AuthAPI.DTO;

public class CompleteOnboardingResponseDTO
{
    public required int StatusCode { get; set; }

    public required string Message { get; set; }
    public string? Token { get; set; }

}
