import boto3
import logging as log

# Set up logging
log.basicConfig(level=log.INFO)


# Set the AWS profile and region
session = boto3.Session(profile_name='AWS-Dev', region_name='ap-southeast-2')
dynamodb = session.resource('dynamodb')

# Define the table
table = dynamodb.Table('StockOnHand')

# Function to put an item into the DynamoDB table
def put_ddb_item(sku, soh):
    log.info(f'Put item {sku} into DynamoDB table')
    response = table.put_item(
        Item={
            'sku': sku,
            'soh': soh
        },
        ReturnConsumedCapacity='TOTAL'
    )
    log.info(f'Consumed capacity: {response["ConsumedCapacity"]}')
    return response

# Function to update an item in the DynamoDB table
def update_ddb_item(sku, new_soh):
    log.info(f'Update item {sku} in DynamoDB table')
    response = table.update_item(
        Key={
            'sku': sku
        },
        UpdateExpression='SET soh = :val',
        ExpressionAttributeValues={
            ':val': new_soh
        },
        ReturnConsumedCapacity='TOTAL'
    )
    log.info(f'Consumed capacity: {response["ConsumedCapacity"]}')
    return response

# Insert items
put_ddb_item('188273', 0)
put_ddb_item('723663', 20)
put_ddb_item('111837', 50)

# Update items
update_ddb_item('188273', 5)
update_ddb_item('723663', 15)
update_ddb_item('111837', 10)

# Additional update
update_ddb_item('111837', 0)
