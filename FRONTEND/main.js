async function GetAreaOutPut()
{
    const response = await fetch('http://localhost:5156/area')
    areares = await response.json()

}

async function SendArea() 
{
    area = document.getElementById("area").value;
    epsilon = document.getElementById("epsilon").value;
    const matrix = area.trim().split('\n').map(row => row.split(';').map(cell => parseInt(cell)))
    console.log(matrix)

    fetch('http://localhost:5156/area', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            plotArea: matrix,
            epsilon: parseInt(epsilon),
        })
    })
        .then(resp => {
            console.log('Response: ', resp)
            if (resp.status === 200) {
                window.location.href = "index.html";
                
            }
        })
        .catch(error => console.log(error))

}

