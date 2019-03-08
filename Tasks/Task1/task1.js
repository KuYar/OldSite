function refresh()
{
	location.reload();
}

function calculate()
{
	var get_text = document.getElementById("text");
	var text = get_text.value;
	var countW = counterOfWords(text);
	var countL = counterOfLetters(text);

	alert("Count of words<"+countW+">");
	for(var i=0;i<countL.length;i++)	
	{
		alert("Count of letters<"+countL[i]+">");	
	}
	alert("Max value - " + Math.max.apply(null,countL));
	alert("Min value - " + Math.min.apply(null,countL));
	alert("Avarage value - " + findAvar(countL));
}

function findAvar(mass)
{
	var avar = 0;
	var sum = 0;
	for(var i=0;i<mass.length;i++)
	{
		sum = sum + mass[i];
	}
	avar = sum/mass.length;
	return avar;
}

function counterOfLetters(str)
{
	var letters = 0;
    var countLetters = [];
    var tmp = str.split(" ");
    for (var i=0; i<tmp.length;i++) 
    {
    	var tmpl = tmp[i].split("");
	    for (var j=0; j<tmpl.length;j++) 
	    {
	    	letters++;
	    	if(tmpl[j]=='-')
			{	
				j++;
			}
	    }
	   	countLetters.push(letters);
	   	letters=0;
	}
    return countLetters;
}

function counterOfWords(str)
{
	var res = str.split(" ");
	var count = 0;
	for(var i =0;i<res.length;i++)
	{
		count++;
		if(res[i]=='-')
		{
			count--;
		}
	}
	return count;
}

