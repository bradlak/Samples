var wordToCheck;
var lastCharacter;
var toCheck;
var chances = 10;

function StartGame(){
	$("#body").keypress(function(e){
	 lastCharacter = String.fromCharCode(e.keyCode);
	 chances--;
	 RefreshChances();

for (var i = 0; i < wordToCheck.length; i++) {
	if(lastCharacter == wordToCheck[i]) toCheck[i] = lastCharacter;
}

	 GenerateWord(toCheck);
	 CheckResults(toCheck);
	});

	 wordToCheck = $("#word")[0].value;

	$("#confirm").attr({'disabled': 'disabled' });
	$("#word").attr({'disabled': 'disabled' });

      toCheck =  wordToCheck.split('');

      for (var i = toCheck.length - 1; i >= 0; i--) {
      	toCheck[i] = '_';
      };
	GenerateWord(toCheck);

 RefreshChances();
}

function GenerateWord(w){
	var dataToDisplay = "";
	for (var i = 0 ; i < w.length; i++) {
		dataToDisplay += w[i] + " ";
	}

	$("#checked").text(dataToDisplay);
}

function RefreshChances(){
	   var data = "Your chances: ";
	   $("#chancesCount").text(data + + chances.toString());
}

function CheckResults(w){
	var missed = 0;
	for (var i = 0; i < w.length; i++) {
		if(w[i] == "_") missed++;
	}

	if(missed == 0){
				$("#result").text("You won!");
		$("#result").css("background-color","green");

	}

	if(chances == 0){
	   $("#result").css("background-color","red");	
	   $("#result").text("You lose!");
	   GenerateWord(wordToCheck);
	}
}