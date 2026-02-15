using Hack.io.CANM;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LaunchCamPlus.Formats;

/// <summary>
/// CANM 2 JSON Converter<para/>
/// Currently supports NoClip.Website version 3
/// </summary>
public static class JSON
{
    private readonly static JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.General) { WriteIndented = true };
    public static string ToJSON(this CANM Source)
    {
        StudioAnimationFile NewJSON = new();

        AddKeyFrames(NewJSON.Animation.PosXTrack, Source[CANM.TrackSelection.PositionX]);
        AddKeyFrames(NewJSON.Animation.PosYTrack, Source[CANM.TrackSelection.PositionY]);
        AddKeyFrames(NewJSON.Animation.PosZTrack, Source[CANM.TrackSelection.PositionZ]);

        AddKeyFrames(NewJSON.Animation.LookAtXTrack, Source[CANM.TrackSelection.TargetX]);
        AddKeyFrames(NewJSON.Animation.LookAtYTrack, Source[CANM.TrackSelection.TargetY]);
        AddKeyFrames(NewJSON.Animation.LookAtZTrack, Source[CANM.TrackSelection.TargetZ]);

        AddKeyFrames(NewJSON.Animation.BankTrack, Source[CANM.TrackSelection.Roll]);
        // for some reason, FoV is not supported on NoClip atm

        return JsonSerializer.Serialize(NewJSON, SerializerOptions);

        static void AddKeyFrames(Track Destination, CANM.Track Source)
        {
            for (int i = 0; i < Source.Count; i++)
            {
                CANM.Track.Frame k = Source[i];
                Keyframe nk = new() { Time = (int)(k.FrameId * 16.666666666666668), Value = k.Value, TangentIn = k.InSlope, TangentOut = k.OutSlope };
                Destination.Keyframes.Add(nk);
            }
        }
    }

    public static CANM FromJSON(this string Source)
    {
        CANM NewKeys = new();

        NewKeys[CANM.TrackSelection.FieldOfView].Add(new() { FrameId = 0, Value = 45 });

        return NewKeys;
    }


    sealed class StudioAnimationFile
    {
        [JsonPropertyName("version")]
        public int Version { get; set; } = 3;

        [JsonPropertyName("animation")]
        public Animation Animation { get; set; } = new();
    }
    sealed class Animation
    {
        [JsonPropertyName("posXTrack")]
        public Track PosXTrack { get; set; } = new();

        [JsonPropertyName("posYTrack")]
        public Track PosYTrack { get; set; } = new();

        [JsonPropertyName("posZTrack")]
        public Track PosZTrack { get; set; } = new();

        [JsonPropertyName("lookAtXTrack")]
        public Track LookAtXTrack { get; set; } = new();

        [JsonPropertyName("lookAtYTrack")]
        public Track LookAtYTrack { get; set; } = new();

        [JsonPropertyName("lookAtZTrack")]
        public Track LookAtZTrack { get; set; } = new();

        [JsonPropertyName("bankTrack")]
        public Track BankTrack { get; set; } = new();

        [JsonPropertyName("loop")]
        public bool Loop { get; set; }
    }
    sealed class Track
    {
        [JsonPropertyName("keyframes")]
        public List<Keyframe> Keyframes { get; set; } = [];
    }
    sealed class Keyframe
    {
        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("tangentIn")]
        public double TangentIn { get; set; }

        [JsonPropertyName("tangentOut")]
        public double TangentOut { get; set; }

        [JsonPropertyName("interpInType")]
        public int InterpInType { get; set; } = 0;

        [JsonPropertyName("interpOutType")]
        public int InterpOutType { get; set; } = 0;

        [JsonPropertyName("easeInCoeff")]
        public double EaseInCoeff { get; set; } = 1;

        [JsonPropertyName("easeOutCoeff")]
        public double EaseOutCoeff { get; set; } = 1;
    }
}
