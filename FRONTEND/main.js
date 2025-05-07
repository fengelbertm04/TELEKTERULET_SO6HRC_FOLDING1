async function GetAreaOutPut()
{
    
}

async function SendArea() 
{
    area = document.getElementById("area").value;
    epsilon = document.getElementById("epsilon").value;
    const matrix = area.trim().split('\n').map(row => row.split(';').map(cell => parseInt(cell)))
    console.log(matrix)
}

