class HomeController {
	constructor(homeView, requester, baseServiceUrl, appKey) {
		this._homeview = homeView;
		this._requester = requester;
		this._appKey = appKey;
		this._baseServiceUrl = baseServiceUrl;		
	}

	showGuestPage() {
		let _that = this;

		let recentPosts = [];

		let requestUrl = this._baseServiceUrl + "/appdata/" + this._appKey + "/posts";

		this._requester.get(requestUrl,
			function success(data) {
				data.sort(function (element1, element2) {
					let date1 = new Date(element1._kmd.ect);
					let date2 = new Date(element2._kmd.ect);
					return date2 - date1;
				});

				let currentId = 1;

				for (let i = 0; i < data.length && i < 5; i++) {
					data[i].postId = currentId;
					currentId++;
					recentPosts.push(data[i]);
				}

				_that._homeview.showGuestPage(recentPosts, data);
			},
			function error(data) {
				showPopup('error', "Error loading posts!");
			}
		);
	}

	showUserPage() {
		let _that = this;

		let recentPosts = [];

		let requestUrl = this._baseServiceUrl + "/appdata/" + this._appKey + "/posts";

		this._requester.get(requestUrl,
			function success(data) {
				data.sort(function (element1, element2) {
					let date1 = new Date(element1._kmd.ect);
					let date2 = new Date(element2._kmd.ect);
					return date2 - date1;
				});

				let currentId = 1;

				for (let i = 0; i < data.length && i < 5; i++) {
					data[i].postId = currentId;
					currentId++;
					recentPosts.push(data[i]);
				}

				_that._homeview.showUserPage(recentPosts, data);
			},
			function error(data) {
				showPopup('error', "Error loading posts!");
			}
		);
	}
}