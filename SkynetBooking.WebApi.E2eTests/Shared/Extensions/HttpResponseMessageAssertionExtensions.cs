using Shouldly;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using SkynetBooking.Application.Common.AppRequests;

namespace SkynetBooking.WebApi.E2eTests.Shared.Extensions;

[ShouldlyMethods]
public static class HttpResponseMessageAssertionsExtensions
{
    public static async Task ShouldHaveStatusCode(
        this HttpResponseMessage target,
        HttpStatusCode expectedStatusCode)
    {
        var responseContent = expectedStatusCode != target.StatusCode ?
            await target.Content.ReadAsStringAsync() :
            "";

        target.StatusCode.ShouldBe(
            expectedStatusCode,
            $"Expected status code {expectedStatusCode} but received status code {target.StatusCode} with " +
                (string.IsNullOrEmpty(responseContent) ?
                    "no content." :
                    $"content:\n{responseContent.Replace("{", "{{").Replace("}", "}}")}"));
    }

    public static async Task ShouldHaveSuccessStatusCode(
        this HttpResponseMessage target)
    {
        var responseContent = target.IsSuccessStatusCode ?
            "" :
            await target.Content.ReadAsStringAsync();

        ((int)target.StatusCode).ShouldBeInRange(200, 299,
            $"Expected status code to be success but received status code {target.StatusCode} with " +
                (string.IsNullOrEmpty(responseContent) ?
                    "no content." :
                    $"content:\n{responseContent.Replace("{", "{{").Replace("}", "}}")}"));
    }

    public static async Task ShouldHaveErrorForField(
        this HttpResponseMessage target,
        string expectedErrorField)
    {
        var responseContent = await target.Content.ReadAsStringAsync();

        JsonDocument errorResponse = null!;

        Should.NotThrow(() =>
        {
            errorResponse = JsonDocument.Parse(responseContent);
        },
            "Expected 400 response content to be standard format: {{ errors: [ {{ name: string }} ]}}.");

        errorResponse.RootElement.TryGetProperty("errors", out var errorsElement).ShouldBeTrue("Expected response content to have key 'errors'.");

        var errorKeys = string.Join(",", errorsElement.EnumerateObject().Select(x => x.Name));

        var errorKeysMessage = errorKeys.Length > 0 ? $"Found error keys: {errorKeys}." : "No error keys found.";

        errorsElement.TryGetProperty(expectedErrorField, out _).ShouldBeTrue($"Expected error for: '{expectedErrorField}'\n{errorKeysMessage}");
    }

    public static async Task ShouldHaveStatusCode400WithErrorForField(
        this HttpResponseMessage target,
        string expectedErrorField)
    {
        await target.ShouldHaveStatusCode(HttpStatusCode.BadRequest);

        await target.ShouldHaveErrorForField(expectedErrorField);
    }

    public static async Task ShouldHaveMessage(
        this HttpResponseMessage target,
        string expectedMessage)
    {
        var appResponse = await target.Content.ReadFromJsonAsync<AppResponse>();

        appResponse.ShouldNotBeNull();

        appResponse.Message.ShouldBe(expectedMessage, $"Expected message \"{expectedMessage}\" but received message \"{appResponse.Message}\"");
    }
}
