const customerUri = 'api/customer';
const accountUri = 'api/account';



function addAccount() {
    const addCustomerIdTextbox = document.getElementById('add-customer-id');
    const addInitialCreditTextbox = document.getElementById('add-initial-credit');

    const item = {
        CustomerId: addCustomerIdTextbox.value,
        InitialCredit: addInitialCreditTextbox.value
    };


    fetch(accountUri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(data => _displayAccount(data, addCustomerIdTextbox.value))
        .then(() => {            
            addCustomerIdTextbox.value = '';
            addInitialCreditTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function getCustomer() {

    const getCustomerIdTextbox = document.getElementById('get-customer-id');

    fetch(`${customerUri}/${getCustomerIdTextbox.value}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => _displayCustomer(data))
        .then(() => {
            getCustomerIdTextbox.value = '';
        })
        .catch(error => console.error('Unable to get item.', error));
}

function clearDataDiv() {
    document.getElementById('dataDivWrapper').style.display = "none";

    document.getElementById('dataDiv').innerHTML = '';
}


function _displayCustomer(data) {
    document.getElementById('dataDivWrapper').style.display = "block";

    const dataDiv = document.getElementById('dataDiv');
    dataDiv.innerHTML = '';



    var customerDataTbl = document.createElement('table');
    customerDataTbl.classList.add('table');

    var customerNameTr = document.createElement('tr');

    var customerNameTh = document.createElement('th');
    customerNameTh.classList.add('col-md-3');
    customerNameTh.innerHTML = "Name";

    var customerNameTd = document.createElement('td');
    customerNameTd.classList.add('col-md-9');
    customerNameTd.innerHTML = data.name;

    customerNameTr.appendChild(customerNameTh);
    customerNameTr.appendChild(customerNameTd);
    customerDataTbl.appendChild(customerNameTr);

    var customerSurnameTr = document.createElement('tr');

    var customerSurnameTh = document.createElement('th');
    customerSurnameTh.classList.add('col-md-3');
    customerSurnameTh.innerHTML = "Surname";

    var customerSurnameTd = document.createElement('td');
    customerSurnameTd.classList.add('col-md-9');
    customerSurnameTd.innerHTML = data.surname;

    customerSurnameTr.appendChild(customerSurnameTh);
    customerSurnameTr.appendChild(customerSurnameTd);
    customerDataTbl.appendChild(customerSurnameTr);
    dataDiv.appendChild(customerDataTbl);




    var panelGroupDiv = document.createElement('div');
    panelGroupDiv.classList.add('panel-group');

    var panelNo = 0;
    if (data.accounts && Array.isArray(data.accounts)) {

        data.accounts.forEach(item => {

            panelNo += 1;

            var panelCollapseId = 'collapse' + panelNo;

            var panelDiv = document.createElement('div');
            panelDiv.classList.add('panel');
            panelDiv.classList.add('panel-default');

            var panelHeaderDiv = document.createElement('div');
            panelHeaderDiv.classList.add('panel-heading');

            var panelTitleH4 = document.createElement('h4');
            panelTitleH4.classList.add('panel-title');

            var panelTitleA = document.createElement('a');
            panelTitleA.setAttribute('data-toggle', 'collapse');
            panelTitleA.href = '#' + panelCollapseId;
            panelTitleA.innerHTML = 'Account no. ' + item.id;

            panelTitleH4.appendChild(panelTitleA);
            panelHeaderDiv.appendChild(panelTitleH4);
            panelDiv.appendChild(panelHeaderDiv);




            var panelCollapseDiv = document.createElement('div');
            panelCollapseDiv.id = panelCollapseId;
            panelCollapseDiv.classList.add('panel-collapse');
            panelCollapseDiv.classList.add('collapse');

            var panelBodyDiv = document.createElement('div');
            panelBodyDiv.classList.add('panel-body');

            var balanceTable = document.createElement('table');
            balanceTable.classList.add('table');

            var balanceTr = document.createElement('tr');

            var balanceTh = document.createElement('th');
            balanceTh.classList.add('col-md-3');
            balanceTh.innerHTML = 'Account Balance';


            var balanceTd = document.createElement('td');
            balanceTd.classList.add('col-md-9');
            balanceTd.innerHTML = item.balance;

            balanceTr.appendChild(balanceTh);
            balanceTr.appendChild(balanceTd);
            balanceTable.appendChild(balanceTr);
            panelBodyDiv.appendChild(balanceTable);

            if (item.transactions.length > 0 && Array.isArray(item.transactions)) {

                var transactionsTable = document.createElement('table');
                transactionsTable.classList.add('table');
                transactionsTable.classList.add('table-bordered');
                transactionsTable.classList.add('table-hover');

                var transactionsTableHead = document.createElement('thead');

                var transactionsTableHeadTr = document.createElement('tr');

                var transactionsTableHeadThID = document.createElement('th');
                transactionsTableHeadThID.classList.add('col-md-6');
                transactionsTableHeadThID.innerHTML = 'Transaction ID';

                var transactionsTableHeadThAmount = document.createElement('th');
                transactionsTableHeadThAmount.classList.add('col-md-6');
                transactionsTableHeadThAmount.innerHTML = 'Amount';

                transactionsTableHeadTr.appendChild(transactionsTableHeadThID);
                transactionsTableHeadTr.appendChild(transactionsTableHeadThAmount);
                transactionsTableHead.appendChild(transactionsTableHeadTr);
                transactionsTable.appendChild(transactionsTableHead);


                var transactionsTableBody = document.createElement('tbody');

           

                item.transactions.forEach(transaction => {
                    var transactionTr = document.createElement('tr');

                    var transactionIDTd = document.createElement('td');
                    transactionIDTd.innerHTML = transaction.id;

                    var transactionAmountTd = document.createElement('td');
                    transactionAmountTd.innerHTML = transaction.amount;

                    transactionTr.appendChild(transactionIDTd);
                    transactionTr.appendChild(transactionAmountTd);
                    transactionsTableBody.appendChild(transactionTr);

                });
                transactionsTable.appendChild(transactionsTableBody);
                panelBodyDiv.appendChild(transactionsTable);
            }
           
            panelCollapseDiv.appendChild(panelBodyDiv);
            panelDiv.appendChild(panelCollapseDiv);
            panelGroupDiv.appendChild(panelDiv);
        });
    }
    dataDiv.appendChild(panelGroupDiv);
}


function _displayAccount(data, customerId) {
    document.getElementById('dataDivWrapper').style.display = "block";

    const dataDiv = document.getElementById('dataDiv');
    dataDiv.innerHTML = '';

  
    var accountTable = document.createElement('table');
    accountTable.classList.add('table');


    var customerTr = document.createElement('tr');

    var customerTh = document.createElement('th');
    customerTh.classList.add('col-md-3');
    customerTh.innerHTML = 'Customer ID';

    var customerTd = document.createElement('td');
    customerTd.classList.add('col-md-9');
    customerTd.innerHTML = customerId;

    customerTr.appendChild(customerTh);
    customerTr.appendChild(customerTd);
    accountTable.appendChild(customerTr);


    var accountTr = document.createElement('tr');

    var accountTh = document.createElement('th');
    accountTh.classList.add('col-md-3');
    accountTh.innerHTML = 'Account ID';

    var accountTd = document.createElement('td');
    accountTd.classList.add('col-md-9');
    accountTd.innerHTML = data.id;

    accountTr.appendChild(accountTh);
    accountTr.appendChild(accountTd);
    accountTable.appendChild(accountTr);



    var balanceTr = document.createElement('tr');

    var balanceTh = document.createElement('th');
    balanceTh.classList.add('col-md-3');
    balanceTh.innerHTML = 'Account Balance';

    var balanceTd = document.createElement('td');
    balanceTd.classList.add('col-md-9');
    balanceTd.innerHTML = data.balance;    

    balanceTr.appendChild(balanceTh);
    balanceTr.appendChild(balanceTd);
    accountTable.appendChild(balanceTr);
    dataDiv.appendChild(accountTable);


    if (data.transactions.length > 0 && Array.isArray(data.transactions)) {

        var transactionsTable = document.createElement('table');
        transactionsTable.classList.add('table');
        transactionsTable.classList.add('table-bordered');
        transactionsTable.classList.add('table-hover');

        var transactionsTableHead = document.createElement('thead');

        var transactionsTableHeadTr = document.createElement('tr');

        var transactionsTableHeadThID = document.createElement('th');
        transactionsTableHeadThID.classList.add('col-md-6');
        transactionsTableHeadThID.innerHTML = 'Transaction ID';

        var transactionsTableHeadThAmount = document.createElement('th');
        transactionsTableHeadThAmount.classList.add('col-md-6');
        transactionsTableHeadThAmount.innerHTML = 'Amount';

        transactionsTableHeadTr.appendChild(transactionsTableHeadThID);
        transactionsTableHeadTr.appendChild(transactionsTableHeadThAmount);
        transactionsTableHead.appendChild(transactionsTableHeadTr);
        transactionsTable.appendChild(transactionsTableHead);


        var transactionsTableBody = document.createElement('tbody');
    
        data.transactions.forEach(transaction => {
            var transactionTr = document.createElement('tr');

            var transactionIDTd = document.createElement('td');
            transactionIDTd.innerHTML = transaction.id;

            var transactionAmountTd = document.createElement('td');
            transactionAmountTd.innerHTML = transaction.amount;

            transactionTr.appendChild(transactionIDTd);
            transactionTr.appendChild(transactionAmountTd);
            transactionsTableBody.appendChild(transactionTr);

        });

        transactionsTable.appendChild(transactionsTableBody);
        dataDiv.appendChild(transactionsTable);
    }

   
}

