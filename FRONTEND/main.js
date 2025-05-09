async function GetAreaOutPut() {
    const response = await fetch('http://localhost:5156/area')
    areares = await response.json()
    console.log(areares);

    const container = document.getElementById('matrix-container');
    const table = document.createElement('table');



    for (let i = 0; i < areares.area.plotArea.length; i++) {
        const tr = document.createElement('tr');

        for (let j = 0; j < areares.area.plotArea[i].length; j++) {
            const td = document.createElement('td');
            td.textContent = areares.area.plotArea[i][j]
        
            if ( j >= areares.startIndex.x && j <= areares.endIndex.x && i >= areares.startIndex.y && i <= areares.endIndex.y)
            {
              
                td.classList.add('highlight');
            }
            tr.appendChild(td);
        }
   
        table.appendChild(tr);
    }  
  container.appendChild(table);
}


async function SendArea() {
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
                GetAreaOutPut();
            }
        })
        .catch(error => console.log(error))


}

