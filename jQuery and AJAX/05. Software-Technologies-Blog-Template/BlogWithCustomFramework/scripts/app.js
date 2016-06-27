(function () {
	let baseUrl = "https://baas.kinvey.com";
	let appKey = "kid_BJER_4RS";
	let appSecret = "f61ad38ffd93438fb9c5ecebe6b1d34d";
	var _guestCredentials = "410b9462-b1d1-460c-9e11-5b431dacf517.mnov6Gb/yKTybDUuhtQeK9hnvYwW2kr9Y8Dy07zPif8=";

	let selector = ".wrapper";
	let mainContentSelector = ".main-content";

	let authService = new AuthorizationService(baseUrl,
		appKey,
		appSecret,
		_guestCredentials);

	authService.initAuthorizationType("Kinvey");

	let requester = new Requester(authService);

	let homeView = new HomeView(selector, mainContentSelector);
	let homeController = new HomeController(homeView, requester, baseUrl, appKey);
	homeController.showGuestPage();

	initEventServices();

	onRoute("#/", function () {
		// Check if user is logged in and if its not show the guest page, otherwise show the user page...
	});

	onRoute("#/post-:id", function () {
		// Create a redirect to one of the recent posts...
	});

	onRoute("#/login", function () {
		// Show the login page...
	});

	onRoute("#/register", function () {
		// Show the register page...
	});

	onRoute("#/logout", function () {
		// Logout the current user...
	});

	onRoute('#/posts/create', function () {
		// Show the new post page...
	});

	bindEventHandler('login', function (ev, data) {
		// Login the user...
	});

	bindEventHandler('register', function (ev, data) {
		// Register a new user...
	});

	bindEventHandler('createPost', function (ev, data) {
		// Create a new post...
	});

	run('#/');
})();

