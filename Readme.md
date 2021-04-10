GiphyExercise Flow of data =

Gif in cache - GiphyWebApi => GiphyController => MemoryCache => GiphyItem
New Gif - GiphyWebApi => GiphyController => GiphyTools => WebTools => Response => MemoryCache => GiphyItem

GiphyExercise is composed of:


1. GiphyWebApi - Asp.net core web api that uses:
	a. GiphyController - using a constructor with dependency injection of logger, configuration, giphyTools, giphyConfig, memoryCache
	   Use async Task to get gifs - Uses Memory Cache to store gifs and show them or fetch new ones from Giphy
	b. Models - Giphy models - models from the Giphy API to get, store and show the objects, 
	   GiphyItem - the result with primary key to store in cache
	c. WebTools - generic methods to get data and parse url according to model class (by Json properties)

2. GiphyWebSite - A simple Angular (11) web ui that shows a search text for the required Gif.
   Shows the url and the gif as result.
   Uses material for input and lables
   Uses rxjs to subscribe to Subject and HttpService to get results
   Use GiphyItem Model like in Server to show search term and url 

TODO - For future enhancements - 
1. Server - Use many tasks and return results as they finished using Task.WhenAny - asynchronously provide the first one that completes and not in the order they were supplied.

Example for solution:

List<Task<T>> tasks = …;
while(tasks.Count > 0) {
    var t = await Task.WhenAny(tasks);
    tasks.Remove(t);
    try { Process(await t); }
    catch(OperationCanceledException) {}
    catch(Exception exc) { Handle(exc); }
}

2. UI - Add search by few terms split by "," to demo the asynchronus Gifs return 
