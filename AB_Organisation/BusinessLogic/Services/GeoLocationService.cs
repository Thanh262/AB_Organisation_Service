using System.Net.Http.Json;
using Common.Models;

namespace BusinessLayer.Services;

public class GeoLocationService
{
    private readonly HttpClient _httpClient;

    public GeoLocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GeoLocationModel> GetGeoLocation(int postId)
    {
        string url = "https://api.addressy.com/GovernmentData/Postzon/RetrieveByPostcode/v1.50/json.ws?Key=PD55-ZM54-HJ92-HP62&Postcode=AL4 0BS";

        //string jsondata = await _httpClient.GetFromJsonAsync<GeoLocationModel>(url);
        
        GeoLocationModel response = await _httpClient.GetFromJsonAsync<GeoLocationModel>(url);

        if (response == null)
        {
            throw new Exception("Failed to retrieve geo location data.");
        }

        response.LocalAuthority = $"{response.DistrictName} Council"; 
        response.UnitaryAuthority = ( string.IsNullOrEmpty(response.CountyCode) && !string.IsNullOrEmpty(response.DistrictName) ) 
            ? response.DistrictName 
            : "none";

        return response;
    }
}