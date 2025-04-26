<?php
# Doctrine Migrations Quick Reference Guide

## Table Creation & Column Types

### Create a Table

$table = $schema->createTable('table_name');


### Common Column Types

// Integer columns
$table->addColumn('id', 'integer', ['autoincrement' => true]);
$table->addColumn('count', 'integer', ['unsigned' => true]);
$table->addColumn('small_int', 'smallint');
$table->addColumn('big_int', 'bigint');

// Text columns
$table->addColumn('name', 'string', ['length' => 255]);
$table->addColumn('description', 'text');
$table->addColumn('char_code', 'string', ['length' => 3, 'fixed' => true]); // CHAR(3)

// Boolean
$table->addColumn('is_active', 'boolean');

// Date and Time
$table->addColumn('created_at', 'datetime');
$table->addColumn('updated_at', 'datetime', ['notnull' => false]);
$table->addColumn('date_only', 'date');
$table->addColumn('time_only', 'time');

// Decimal and Float
$table->addColumn('price', 'decimal', ['precision' => 10, 'scale' => 2]);
$table->addColumn('rate', 'float');

// Binary data
$table->addColumn('image_data', 'blob');

// JSON (MySQL 5.7+, PostgreSQL, etc.)
$table->addColumn('metadata', 'json');

// Array (PostgreSQL)
$table->addColumn('tags', 'array', ['notnull' => false]);


### Column Options

$table->addColumn('column_name', 'string', [
    'length' => 100,             // For string type
    'notnull' => false,          // Allow NULL values
    'default' => 'Default text', // Default value
    'comment' => 'Column description',
    'unsigned' => true,          // For integer types
    'autoincrement' => true,     // For primary keys
    'precision' => 10,           // For decimal/numeric
    'scale' => 2,                // Decimal places
    'fixed' => true,             // For CHAR vs VARCHAR
    'customSchemaOptions' => [   // Database-specific options
        'charset' => 'utf8mb4'
    ]
]);


## Keys and Indexes

### Primary Key

// Single column primary key
$table->setPrimaryKey(['id']);

// Composite primary key
$table->setPrimaryKey(['order_id', 'product_id']);


### Unique Indexes

// Single column unique index
$table->addUniqueIndex(['email'], 'idx_email_unique');

// Multi-column unique index
$table->addUniqueIndex(['first_name', 'last_name'], 'idx_name_unique');


### Regular Indexes

// Single column index
$table->addIndex(['category_id'], 'idx_category');

// Multi-column index
$table->addIndex(['last_name', 'first_name'], 'idx_name');

// Index with custom flags
$table->addIndex(['description'], 'idx_description', [], ['lengths' => [100]]);


## Foreign Keys

### Basic Foreign Key

$table->addForeignKeyConstraint(
    'categories',             // Referenced table
    ['category_id'],          // Local columns
    ['id'],                   // Referenced columns
    [],                       // Options
    'fk_product_category'     // Constraint name
);


### Foreign Key with Options

$table->addForeignKeyConstraint(
    'users',
    ['user_id'], 
    ['id'],
    [
        'onDelete' => 'CASCADE',        // CASCADE, SET NULL, NO ACTION, RESTRICT
        'onUpdate' => 'NO ACTION',
        'notnull' => false              // Allow nullable foreign key
    ],
    'fk_post_user'
);


## Schema Modifications

### Modifying Existing Tables


// Get an existing table
$table = $schema->getTable('users');

// Add a new column
$table->addColumn('middle_name', 'string', ['length' => 100, 'notnull' => false]);

// Drop a column
$table->dropColumn('obsolete_column');

// Check if column exists
if ($table->hasColumn('column_name')) {
    // Do something
}

// Change column definition
$table->changeColumn('description', [
    'type' => 'text',
    'notnull' => false
]);


### Working with Indexes

// Check if index exists
if ($table->hasIndex('idx_name')) {
    $table->dropIndex('idx_name');
}

// Add index
$table->addIndex(['column_name'], 'new_idx_name');


### Working with Foreign Keys

// Check if foreign key exists
if ($table->hasForeignKey('fk_name')) {
    $table->removeForeignKey('fk_name');
}

// Add a new foreign key
$table->addForeignKeyConstraint('related_table', ['related_id'], ['id']);


## Direct SQL Execution


// For operations that schema builder doesn't support
$this->addSql('ALTER TABLE users ADD FULLTEXT INDEX idx_fulltext (title, content)');

// Insert data
$this->addSql("INSERT INTO config (key, value) VALUES ('app_version', '1.0.0')");

// Execute multiple statements
$this->addSql('
    CREATE PROCEDURE get_users()
    BEGIN
        SELECT * FROM users;
    END
');


## Common Migration Patterns

### Create a Table with Relations


public function up(Schema $schema): void
{
    // Create main table
    $table = $schema->createTable('products');
    $table->addColumn('id', 'integer', ['autoincrement' => true]);
    $table->addColumn('name', 'string', ['length' => 100]);
    $table->addColumn('price', 'decimal', ['precision' => 10, 'scale' => 2]);
    $table->addColumn('category_id', 'integer', ['notnull' => false]);
    $table->addColumn('created_at', 'datetime', ['default' => 'CURRENT_TIMESTAMP']);
    $table->setPrimaryKey(['id']);
    
    // Add indexes
    $table->addIndex(['name'], 'idx_product_name');
    
    // Add foreign key
    $table->addForeignKeyConstraint(
        'categories',
        ['category_id'],
        ['id'],
        ['onDelete' => 'SET NULL'],
        'fk_product_category'
    );
}

public function down(Schema $schema): void
{
    // Drop the table and all its keys
    $schema->dropTable('products');
}


### Create a Join Table (Many-to-Many)


public function up(Schema $schema): void
{
    $table = $schema->createTable('products_tags');
    $table->addColumn('product_id', 'integer');
    $table->addColumn('tag_id', 'integer');
    $table->setPrimaryKey(['product_id', 'tag_id']);
    
    // Add foreign keys
    $table->addForeignKeyConstraint(
        'products',
        ['product_id'],
        ['id'],
        ['onDelete' => 'CASCADE'],
        'fk_product_tag_product'
    );
    
    $table->addForeignKeyConstraint(
        'tags',
        ['tag_id'],
        ['id'],
        ['onDelete' => 'CASCADE'],
        'fk_product_tag_tag'
    );
}


### Add Timestamp Columns


public function up(Schema $schema): void
{
    $table = $schema->getTable('users');
    $table->addColumn('created_at', 'datetime', ['default' => 'CURRENT_TIMESTAMP']);
    $table->addColumn('updated_at', 'datetime', [
        'notnull' => false,
        'default' => null,
        'comment' => 'Last update timestamp'
    ]);
    
    // Add a trigger to update the updated_at field
    $this->addSql('
        CREATE TRIGGER users_updated_at
        BEFORE UPDATE ON users
        FOR EACH ROW
        SET NEW.updated_at = CURRENT_TIMESTAMP
    ');
}


### Add Soft Delete Column


public function up(Schema $schema): void
{
    $table = $schema->getTable('posts');
    $table->addColumn('deleted_at', 'datetime', ['notnull' => false, 'default' => null]);
    $table->addIndex(['deleted_at'], 'idx_post_deleted');
}
