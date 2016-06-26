const kinveyBaseUrl = "http://baas.kinvey.com/";
const kinveyAppKey = "kid_BkXZPV6S";
const kinveyAppSecret = "43fe6a16a7d4421e977d4f2d5307f1ef";

$(function () {
	showHideMenuLinks();
	showView('viewHome');
	$("#linkHome").click(showHomeView);
	$("#linkLogin").click(showLoginView);
	$("#linkRegister").click(showRegisterView);
	$("#linkListBooks").click(showListBooksView);
	$("#linkCreateBook").click(showCreateBookView);
	$("#linkLogout").click(showLogoutView);
	$("#formLogin").submit(function (element) {
		element.preventDefault();
		login();
	});
	$("#formRegister").submit(function (element) {
		element.preventDefault();
		register();
	});
	$("#formCreateBook").submit(function (element) {
		element.preventDefault();
		createBook();
	});

	$('#addCommentButton').click(addBookComment);


	$(document).on({
		ajaxStart: function () {
			$("#loadingBox").show();
		},
		ajaxStop: function () {
			$("#loadingBox").hide();
		}
	})
});

function showView(viewId) {
	$("main > section").hide();
	$("#" + viewId).show();
}

function showHideMenuLinks() {
	$("#linkHome").show();
	if (sessionStorage.getItem('authToken') == null) {
		$("#linkLogin").show();
		$("#linkRegister").show();
		$("#linkListBooks").hide();
		$("#linkCreateBook").hide();
		$("#linkLogout").hide();
	}
	else {
		$("#linkLogin").hide();
		$("#linkRegister").hide();
		$("#linkListBooks").show();
		$("#linkCreateBook").show();
		$("#linkLogout").show();
	}
}

function showInfo(message) {
	$('#infoBox').text(message);
	$('#infoBox').show();
	setTimeout(function () {
		$('#infoBox').fadeOut()
	}, 3000);
}

function showError(errorMessage) {
	$('#errorBox').text("Error: " + errorMessage);
	$('#errorBox').show();
}

function showHomeView() {
	showView("viewHome");
}

function showLoginView() {
	showView("viewLogin");
}

function handleAjaxError(response) {
	let errorMessage = JSON.stringify(response);
	if (response.readyState == 0) {
		errorMessage = "Cannot connect due to network error.";
	}
	if (response.responseJSON && response.responseJSON.description) {
		errorMessage = response.responseJSON.description;
	}
	showError(errorMessage);
}

function login() {
	const kinveyLoginUrl = kinveyBaseUrl + "user/" + kinveyAppKey + "/login";
	const kinveyAuthHeaders = {'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret)};
	let userData = {
		username: $('#loginUsername').val(),
		password: $('#loginPassword').val()
	};
	$.ajax({
		method: "POST",
		url: kinveyLoginUrl,
		headers: kinveyAuthHeaders,
		data: userData,
		success: loginSuccess,
		error: handleAjaxError
	});

	function loginSuccess(response) {
		let userAuth = response._kmd.authtoken;
		sessionStorage.setItem('authToken', userAuth);
		showHideMenuLinks();
		listBooks();
		showInfo('Login successful.');
	}
}

function showRegisterView() {
	showView("viewRegister");
}

function register() {
	const kinveyRegisterUrl = kinveyBaseUrl + "user/" + kinveyAppKey + "/";
	const kinveyAuthHeaders = {'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret)};
	let userData = {
		username: $('#registerUsername').val(),
		password: $('#registerPassword').val()
	};
	$.ajax({
		method: "POST",
		url: kinveyRegisterUrl,
		headers: kinveyAuthHeaders,
		data: userData,
		success: registerSuccess,
		error: handleAjaxError
	});

	function registerSuccess(response) {
		let userAuth = response._kmd.authtoken;
		sessionStorage.setItem('authToken', userAuth);
		showHideMenuLinks();
		listBooks();
		showInfo('User registration successful.');
	}
}

function showListBooksView() {
	showView("viewListBooks");
}

function listBooks() {
	$('#books').empty();
	showView('viewBooks');

	const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books";
	const kinveyAuthHeaders = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};
	$.ajax({
		method: "GET",
		url: kinveyBooksUrl,
		headers: kinveyAuthHeaders,
		success: loadBooksSuccess,
		error: handleAjaxError
	});
	function loadBooksSuccess(books) {
		showInfo('Books loaded.');
		if (books.length == 0) {
			$('#books').text('No books in the library.');
		}
		else {
			let booksTable = $('<table>')
				.append($('<tr>')
					.append('<th>Title</th>', '<th>Author</th>', '<th>Description</th>')
				);
			for (let book of books) {
				booksTable.append($('<tr>')
					.append($('<td>').text(book.title),
						$('<td>').text(book.author),
						$('<td>').text(book.description)))
					.append($('<tr><td colspan="3"></td>'))
					.append($('<div></div>'), $('<div></div>'), $('<div><a href="#" onclick="showAddCommentForm()"> [Add comment]</a> </div>')
					);
			}
			$('#books').append(booksTable);
		}

	}
}

function showCreateBookView() {
	showView("viewCreateBook");
}

function createBook() {
	const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books";
	const kinveyAuthHeaders = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};

	let bookData = {
		title: $('#title').val(),
		author: $('#author').val(),
		description: $('#description').val()
	};

	$.ajax({
		method: "POST",
		url: kinveyBooksUrl,
		headers: kinveyAuthHeaders,
		data: bookData,
		success: createBooksSuccess,
		error: handleAjaxError
	});

	function createBooksSuccess() {
		listBooks();
		showInfo('Book created.')
	}
}

function showLogoutView() {
	sessionStorage.clear();
	showHideMenuLinks();
	showHomeView();
}

function showAddCommentForm() {
	$('#addCommentForm').show();
}

function addBookComment(bookData, commentText, commentAuthor) {
	const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books";
	const kinveyHeaders = {
		'Authorization': "Kinvey" + sessionStorage.getItem('authToken'),
		'Content-type': "application/json"
	};

	if (!bookData.comments) {
		bookData.comments = [];
	}
	bookData.comments.push({text: commentText, author: commentAuthor});

	$.ajax({
		method: "PUT",
		url: kinveyBooksUrl + '/' + bookData._id,
		headers: kinveyHeaders,
		data: JSON.stringify(bookData),
		success: addBookCommentSuccess,
		error: handleAjaxError
	});

	function addBookCommentSuccess() {
		listBooks();
		showInfo('Book comment added.')
	}
}


