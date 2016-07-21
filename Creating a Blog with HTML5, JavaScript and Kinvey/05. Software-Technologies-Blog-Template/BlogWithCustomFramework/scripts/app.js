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

	let userView = new UserView(selector, mainContentSelector);
	let userController = new UserController(userView, requester, baseUrl, appKey);

	let postView = new PostView(selector, mainContentSelector);
	let postController = new PostController(postView, requester, baseUrl, appKey);

	initEventServices();

	onRoute("#/", function () {
		if (authService.isLoggedIn()) {
			homeController.showUserPage();
		}
		else {
			homeController.showGuestPage();
		}
	});

	onRoute("#/post-:id", function () {
		let top = $("#post-" + this.params['id']).position().top;
		$(window).scrollTop(top);
	});

	onRoute("#/login", function () {
		userController.showLoginPage(authService.isLoggedIn());
	});

	onRoute("#/register", function () {
		userController.showRegisterPage(authService.isLoggedIn());
	});

	onRoute("#/logout", function () {
		userController.logout();
	});

	onRoute('#/posts/create', function () {
		let data = {fullName: sessionStorage['fullName']};

		postController.showCreatePostPage(data, authService.isLoggedIn());
	});

	bindEventHandler('login', function (ev, data) {
		userController.login(data)
	});

	bindEventHandler('register', function (ev, data) {
		userController.register(data)
	});

	bindEventHandler('createPost', function (ev, data) {
		postController.createPost(data);
	});

	run('#/');
})();

