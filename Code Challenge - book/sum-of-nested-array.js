
function print(msg) {
    console.log(msg);
}

//TODO: How to use reduce with prototype?
print(Array.prototype.reduce.call([ 1, 1, 1 ], function(el, sum) {
    return el + sum;
}, 0));

function recursiveSumOfArray(array) {

    //TODO: How to invoke property (non-method) of an object via prototype
    var arrayLength = array.length;
    var sum = 0;

    for(var i = 0; i < arrayLength; i++) {
        if(Array.isArray(array[i])) {
            sum = sum + recursiveSumOfArray(array[i]);
            continue;
        }
        sum = sum + array[i];
    }

    return sum;
}

print(recursiveSumOfArray([ 1, 1, 1, [ 3, 4, [ 8 ] ], [ 5 ] ]));