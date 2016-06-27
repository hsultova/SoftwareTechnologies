class HomeView {
	constructor(wrapperSelector, mainContentSelector) {
		this._wrapperSelector = wrapperSelector;
		this._mainContentSelector = mainContentSelector;
	}

	showGuestPage(sideBarData, mainData) {
		let _that = this;

		$.get('templates/welcome-guest.html', function (template) {
			let renderedWrapper = Mustache.render(template, null);

			$(_that._wrapperSelector).html(renderedWrapper);

			$.get('templates/recent-posts.html', function (template) {
				let recentPosts = {recentPosts: sideBarData};

				let renderedRecentPosts = Mustache.render(template, recentPosts);
				$('.recent-posts').html(renderedRecentPosts);
			});

			$.get('templates/posts.html', function (tempalte) {
				let blogPosts = {blogPosts: mainData};

				let renderedPosts = Mustache.render(tempalte, blogPosts);
				$('.articles').html(renderedPosts);
			});
		});
	}

	showUserPage(sideBarData, mainData) {
		let _taht = this;

		$.get('tempaltes/welcome-user.html', function (template) {
			let renderedWrapper = Mustache.render(tempalte, null);

			$(_taht._wrapperSelector).html(renderedWrapper);

			$.get('tempaltes/recent-posts.html', function (template) {
				let recentPosts = {recentPosts: sideBarData};

				let renderedRecentPosts = Mustache.render(template, recentPosts);
				$('.recent-posts').html(renderedRecentPosts);
			});

			$.get('templates/posts.html', function (tempalte) {
				let blogPosts = {blogPosts: mainData};

				let renderedPosts = Mustache.render(tempalte, blogPosts);
				$('.articles').html(renderedPosts);
			});
		});
	}
}


