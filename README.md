# Unity Timeline  Dynamic Music
Simple way of using timeline for dynamic music

This scripts help to create dynamic music in Unity without middleware FMOD or Wwise.

To make it work you need add empty gameobject to scene. Name it for example "MusicTimeline". Create a timeline on it. Uncheck "Play on Awake". Add script MusicTimelineManager to it. 
Then add another empty gameobject as child of "MusicTimeline" and called it "track01". Add script called Track to this object. 

