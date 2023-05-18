public void MoveTargetToRandomPosition() {
    var newTargetPos = m_startingPos + (Random.insideUnitSphere * spawnRadius);
    newTargetPos.y = m_startingPos.y;
    transform.position = newTargetPos;
}