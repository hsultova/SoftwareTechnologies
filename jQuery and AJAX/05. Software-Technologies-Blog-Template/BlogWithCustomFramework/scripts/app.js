(function () {
	let baseUrl = "https://baas.kinvey.com";
	let appKey = "kid_BJER_4RS";
	let appSecret = "f61ad38ffd93438fb9c5ecebe6b1d34d";
	var _guestCredentials = "Basic Z3Vlc3Q6Z3Vlc3Q=";

	let selector = ".wrapper";
	let mainContentSelector = ".main-content";

	let authService = new AuthorizationService(baseUrl,
		appKey,
		appSecret,
		_guestCredentials);

	authService.initAuthorizationType("Kinvey");

	let requester = new Requester(authService);

	let homeView = new HomeView(selector, mainContentSelector);
	homeView.showGuestPage();

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

