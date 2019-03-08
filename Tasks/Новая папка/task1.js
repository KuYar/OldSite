window.onload=function()
{
	var text=document.getElementById("t");
	text.value=null;
  text.style.background = 'snow';
}

var sum=0;
var count=0;

function calculate(){
	var temp=document.getElementById("t").value;
	temp=TextClear(temp);
	var l1=document.getElementById("l1");
	count=WordsNumber(temp);
	l1.innerHTML=count;
	var l2=document.getElementById("l2");
	l2.innerHTML=MaxLength(temp);
	var l3=document.getElementById("l3");
	l3.innerHTML=MinLength(temp);
	var l4=document.getElementById("l4");
	l4.innerHTML=(sum/count);
}

function TextClear(s)
{
	var arr=s.split("");
	for (var i=0; i<arr.length; ++i)
		if (arr[i]=='\n') arr[i]=' ';
	for(var i=0; i<arr.length-1; ++i)
	{
		if ( (arr[i]==',' || arr[i]=='.' || arr[i]=='-' || arr[i]=='_'
		||arr[i]==' ' || arr[i]=='(' || arr[i]==')') 
			&& (arr[i+1].toLowerCase() == arr[i+1].toUpperCase()) )
		{
			arr.splice(i, 1);
			i--;
		}
	}
	var res=arr.join("");
	return res;
}

function WordsNumber(s)
{
	if (s.length==0) return 0;
	var arr=s.split(" ");
	return arr.length;
}

function MaxLength(s)
{
	var max=0;
	var arr=s.split(" ");
	arr.forEach( function(element, index) {
		sum+=element.length;
		if (element.length>max)
			max=element.length;
	});
	return max;
}

function MinLength(s)
{
	var arr=s.split(" ");
	var min=arr[0].length;
	arr.forEach( function(element, index) {
		if (element.length<min)
			min=element.length;
	});
	return min;
}