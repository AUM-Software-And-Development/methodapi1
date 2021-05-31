function HTTPGET(inputString) {
    const HTTP_GET = new XMLHttpRequest();
    const GET_API = "https://localhost:44393/api/interpreter/";
    HTTP_GET.open("GET", GET_API, false);
    HTTP_GET.send();

    console.log(GET_API);
    console.log(HTTP_GET.responseText);

    HTTP_GET.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            GetIndexUXContext(HTTP_GET.responseText);
        }
    }

    // Test key: TESTINGIO

    //Ready states:
    //0	UNSENT	Client has been created.open() not called yet.
    //1	OPENED	open() has been called.
    //2	HEADERS_RECEIVED	send() has been called, and headers and status are available.
    //3	LOADING	Downloading; responseText holds partial data.
    //4	DONE	The operation is complete.
}

function HTTPPOST(inputString) {
    const HTTP_POST = new XMLHttpRequest();
    const POST_API = "https://localhost:44393/api/interpreter/";
    HTTP_POST.open("POST", POST_API, false);
    HTTP_POST.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
    HTTP_POST.send(JSON.stringify(inputString));

    console.log(POST_API);
    console.log("Post request: " + HTTP_POST.responseText);

    GetIndexUXContext(HTTP_POST.responseText);

    // Test key: TESTINGIO

    //Ready states:
    //0	UNSENT	Client has been created.open() not called yet.
    //1	OPENED	open() has been called.
    //2	HEADERS_RECEIVED	send() has been called, and headers and status are available.
    //3	LOADING	Downloading; responseText holds partial data.
    //4	DONE	The operation is complete.
}

function GetIndexUXContext(inputString) {
    const IndexUX = document.querySelector('#IndexUX');
    const CtxIndexUX = IndexUX.getContext('2d');
    IndexUX.width = 720;
    IndexUX.height = 720;
    /* Const for button. */

    if (inputString === "\"blue\"") {
        CtxIndexUX.fillStyle = "blue";
        CtxIndexUX.fillRect(0, 0, IndexUX.width, IndexUX.height);
    }
    else {
        CtxIndexUX.fillStyle = "grey";
        CtxIndexUX.fillRect(0, 0, IndexUX.width, IndexUX.height);
    }
    console.log("Canvas: " + inputString);

    CtxIndexUX.font = "27px Arial";
    CtxIndexUX.strokeStyle = "white";
    CtxIndexUX.strokeText("API call resulted in: " + inputString, 10, 27);
}